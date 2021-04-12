import { all, call, takeLatest, put, fork } from 'redux-saga/effects';
import { registerUser } from '../../api/userApi';
import { userRegisterFailure, userRegisterSucceed } from '../actions/userActions';
import userActionTypes from '../constant/userActionTypes';


function* workerUserRegister(model) {
        try {
                const data = yield call(() => registerUser(model.payload));
                console.log(data)
                if (data.status === 200) {
                        yield put(userRegisterSucceed(data.data))

                }
                else {
                        yield put(userRegisterFailure(data.data.errors))

                }

        }
        catch (error) {
                console.log(error.response.data.errors)
                yield put(userRegisterFailure(error))

        }

}
export function* watchUserRegister() {
        yield takeLatest(userActionTypes.USER_REGISTER_REQUEST, workerUserRegister)
}
const userSagas = [fork(watchUserRegister)]

export default userSagas;