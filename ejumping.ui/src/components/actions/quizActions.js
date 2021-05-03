import quizActionTypes from '../constant/quizActionTypes';
export const loadQuestionRequest = (type, id, page, pageSize) => ({
        type: quizActionTypes.LOAD_QUESTION_REQUEST,
        payload:
        {
                page,
                pageSize,
                type,
                id
        }
});
export const loadQuestionSuccess = (result) =>
({
        type: quizActionTypes.LOAD_QUESTION_SUCCEED,
        payload: result
})
export const loadQuestionFailure = (err) =>
({
        type: quizActionTypes.LOAD_QUESTION_FAILURE,
        payload: err
})
