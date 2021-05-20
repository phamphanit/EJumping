import { combineReducers } from 'redux';
import { connectRouter } from 'connected-react-router';
import userReducer from './../components/reducers/userReducer';
import quizReducer from '../components/reducers/quizReducer';

const rootReducer = (history) => combineReducers(
        {
                router: connectRouter(history),
                user: userReducer,
                quiz: quizReducer
        }
)
export default rootReducer