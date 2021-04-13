import { all, call, takeLatest, put, fork } from 'redux-saga/effects';
import { registerUser, request } from '../../api/userApi';
import { userLoginSucceed, userLogoutSuccess, userRegisterFailure, userRegisterSucceed } from '../actions/userActions';
import userActionTypes from '../constant/userActionTypes';
import { Cookies } from 'react-cookie';

function* workerUserRegister(model) {
        // try {
        //         const data = yield call(() => registerUser(model.payload));
        //         console.log(data)
        //         if (data.status === 200) {
        //                 yield put(userRegisterSucceed(data.data))

        //         }
        //         else {
        //                 yield put(userRegisterFailure(data.data.errors))

        //         }

        // }
        // catch (error) {
        //         console.log(error.response.data.errors)
        //         yield put(userRegisterFailure(error))

        // }


        try {
                const response = yield call(request, '/api/auth/register', model.payload)
                if (response.status === 200) {
                        yield put(userRegisterSucceed(response.data))
                        yield put(userLoginSucceed(response.data))
                }
                else {
                        yield put(userRegisterFailure(response.request.response));
                }
        }
        catch (error) {
                yield put(userRegisterFailure(error))
        }
}
function* workerUserLogin(model) {
        const cookie = new Cookies();
        const act = cookie.get('act');
        console.log(act);
        const data = { access_token: "12312123" }
        yield put(userLoginSucceed(data));
}
function* workerUserLogout() {
        yield put(userLogoutSuccess());
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
const userSagas = [
        fork(watchUserRegister),
        fork(watchUserLogin),
        fork(watchUserLogout)
]

export default userSagas;