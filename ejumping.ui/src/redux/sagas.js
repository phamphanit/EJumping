import { all } from 'redux-saga/effects'
import quizSagas from '../components/sagas/quizSaga';
import userSaga from '../components/sagas/userSaga';
function* rootSaga() {
        yield all([...userSaga, ...quizSagas]);
}
export default rootSaga;