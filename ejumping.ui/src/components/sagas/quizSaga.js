import { fork, put, takeLatest } from "@redux-saga/core/effects";
import quizActionTypes from "../constant/quizActionTypes";
import { loadQuestionFailure, loadQuestionSuccess } from '../actions/quizActions';
import { request } from "../../api/userApi";
import { call } from 'redux-saga/effects';
const quizSagas = [
        fork(watchQuestionFetching)
]
function* workerLoadQuestions(model) {
        try {
                const { page, pageSize = 5, type } = model.payload;
                console.log(pageSize);
                const response = yield call(request, `/api/quiz/${type}?page=${page}&pageSize=${pageSize}`);
                if (response.status === 200) {
                        console.log(response);
                        yield put(loadQuestionSuccess(response.data))
                        console.log("heyyy")
                }
        }
        catch (err) {
                yield put(loadQuestionFailure(err))
        }
}
export function* watchQuestionFetching() {
        yield takeLatest(quizActionTypes.LOAD_QUESTION_REQUEST, workerLoadQuestions);
}
export default quizSagas;