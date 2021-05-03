import quizActionTypes from "../constant/quizActionTypes"

const initialState = {
        isFetching: false,
        questions: null,
        errorFetching: ""
}
const quizReducer = (state = initialState, action) => {
        switch (action.type) {
                case quizActionTypes.LOAD_QUESTION_REQUEST:
                        return {
                                ...state,
                                isFetching: true
                        }
                case quizActionTypes.LOAD_QUESTION_SUCCEED:
                        return {
                                ...state,
                                isFetching: false,
                                questions: action.payload
                        }
                case quizActionTypes.LOAD_QUESTION_FAILURE:
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
