import { all, call } from 'redux-saga/effects'
import userSaga from '../components/sagas/userSaga';
function* rootSaga() {
        yield all([...userSaga]);
}
export default rootSaga;