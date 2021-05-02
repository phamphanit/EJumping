import quizActionTypes from "../constant/quizActionTypes"

const initialState = {
        isFetching: false,
        questions: null,
        errorFetching: ""
}
const quizReducer = (state = initialState, action) => {
        switch (action.type) {
                case quizActionTypes.LOAD_QUESTION_RESULT_REQUEST:
                        return {
                                ...state,
                                isFetching: true
                        }
                case quizActionTypes.LOAD_QUESTION_RESULT_SUCCEED:
                        return {
                                ...state,
                                isFetching: false,
                                questions: { ...state.quiz.questions, ...action.payload }
                        }
                case quizActionTypes.LOAD_QUESTION_RESULT_FAILURE:
                        return {
                                ...state,
                                isFetching: false,
                                errorFetching: action.payload
                        }
                default:
                        return state;
        }
}
export default quizReducer;
