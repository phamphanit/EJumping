import { all, call, takeLatest, put, fork } from 'redux-saga/effects';
import { registerUser, request } from '../../api/userApi';
import { userLoginSucceed, userRegisterFailure, userRegisterSucceed } from '../actions/userActions';
import userActionTypes from '../constant/userActionTypes';

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
                        console.log("bbbbbbbb")

                        yield put(userRegisterFailure(response.request.response));
                }
        }
        catch (error) {
                console.log("aaaaaaaaaaaa")
                yield put(userRegisterFailure(error))

        }
}
export function* watchUserRegister() {
        yield takeLatest(userActionTypes.USER_REGISTER_REQUEST, workerUserRegister)
}
const userSagas = [fork(watchUserRegister)]

export default userSagas;