import { fork, put, takeLatest } from "@redux-saga/core/effects";
import quizActionTypes from "../constant/quizActionTypes";
import { loadQuestionFailure, loadQuestionSuccess } from '../actions/quizActions';
// import { request } from "../../api/userApi";
import request from '../../api/request';
import { call } from 'redux-saga/effects';
const quizSagas = [
        fork(watchQuestionFetching)
]
function* workerLoadQuestions(model) {
        // try {
        //         const { page, pageSize = 5, type } = model.payload;
        //         const response = yield call(request, `/api/quiz/${type}?page=${page}&pageSize=${pageSize}`);
        //         if (response.status === 200) {
        //                 yield put(loadQuestionSuccess(response.data))
        //         }
        //         else {
        //                 throw response;
        //         }

        // }
        // catch (err) {
        //         yield put(loadQuestionFailure(err))
        // }
        try {
                const { page, pageSize = 5, type } = model.payload;
                const result = yield call(request, `/api/quiz/${type}?page=${page}&pageSize=${pageSize}`);
                yield put(loadQuestionSuccess(result))

        }
        catch (error) {
                console.log(error);
                yield put(loadQuestionFailure(error.response.data))
        }

}
export function* watchQuestionFetching() {
        yield takeLatest(quizActionTypes.LOAD_QUESTION_REQUEST, workerLoadQuestions);
}
export default quizSagas;