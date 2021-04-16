import { all, call, takeLatest, put, fork } from 'redux-saga/effects';
import * as api from '../../api/userApi';
import * as action from '../actions/userActions';
import userActionTypes from '../constant/userActionTypes';

const userSagas = [
        fork(watchUserRegister),
        fork(watchUserLogin),
        fork(watchUserLogout),
        fork(watchfetchMyInfo)
]
function* workerUserRegister(model) {
        try {
                const response = yield call(api.request, '/api/auth/register', model.payload)
                if (response.status === 200) {
                        yield put(action.userRegisterSucceed(response.data))
                        yield put(action.userLoginSucceed(response.data))
                }
                else {
                        yield put(action.userRegisterFailure(response.request.response));
                }
        }
        catch (error) {
                yield put(action.userRegisterFailure(error))
        }
}
function* workerUserLogin(model) {
        try {
                const response = yield call(api.request, '/api/auth/login', model.payload)
                if (response.status === 200) {
                        yield put(action.userLoginSucceed(response.data));
                        yield put(action.fetchMyInfoRequested())
                } else {
                        yield put(action.userLoginFailure(response.request.response));
                }
        }
        catch (err) {

                yield put(action.userLoginFailure(err));
        }
}
function* workerUserLogout() {
        yield put(action.userLogoutSuccess());
}
function* workerFetchMyInfo() {
        try {
                const response = yield call(() => api.getLoggedInUser());
                if (response.status === 200) {
                        yield put(action.fetchMyInfoSucceed(response.data))
                }
                else yield put(action.fetchMyInfoFailure(response.request.response));
        }
        catch (err) {
                yield put(action.fetchMyInfoFailure(err))
        }
}
export function* watchUserRegister() {
        yield takeLatest(userActionTypes.USER_REGISTER_REQUEST, workerUserRegister)
}
export function* watchUserLogin() {
        yield takeLatest(userActionTypes.USER_LOGIN_REQUEST, workerUserLogin)
}
export function* watchUserLogout() {
        yield takeLatest(userActionTypes.USER_LOGOUT_REQUESTED, workerUserLogout)
}
export function* watchfetchMyInfo() {
        yield takeLatest(userActionTypes.FETCH_MYINFO_REQUESTED, workerFetchMyInfo)
}


export default userSagas;