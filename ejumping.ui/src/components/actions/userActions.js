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
export const userLoginRequest = model =>
({
        type: userActionTypes.USER_LOGIN_REQUEST,
        payload: model
})
export const userLoginSucceed = (data) => ({
        type: userActionTypes.USER_LOGIN_SUCCESS,
        payload: data
})
export const userLoginFailure = (err) => ({
        type: userActionTypes.USER_LOGIN_FAILURE,
        payload: err
})
export const userLogoutRequest = () => ({
        type: userActionTypes.USER_LOGOUT_REQUESTED,
})
export const userLogoutSuccess = () => ({
        type: userActionTypes.USER_LOGOUT_SUCCESS,
})
export const userLogoutFailure = (err) => ({
        type: userActionTypes.USER_LOGOUT_FAILURE,
        payload: err

})
export const fetchMyInfoRequested = () => ({
        type: userActionTypes.FETCH_MYINFO_REQUESTED,
})
export const fetchMyInfoSucceed = (model) => ({
        type: userActionTypes.FETCH_MYINFO_SUCCEEDED,
        payload: model
})
export const fetchMyInfoFailure = (err) => ({
        type: userActionTypes.FETCH_MYINFO_FAILURE,
        payload: err
})
export const userExternalLogin = (res) => ({
        type: userActionTypes.USER_EXTERNAL_LOGIN_REQUEST,
        payload: res
})