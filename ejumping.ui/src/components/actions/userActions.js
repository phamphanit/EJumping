import userActionTypes from "../constant/userActionTypes"

export const userRegisterRequested = (model) =>
({
        type: userActionTypes.USER_REGISTER_REQUEST,
        payload: model
})
export const userRegisterSucceed = () =>
({
        type: userActionTypes.USER_REGISTER_SUCCESS
})
export const userRegisterFailure = (err) =>
({
        type: userActionTypes.USER_REGISTER_FAILURE,
        payload: err
})