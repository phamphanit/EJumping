import { combineReducers } from 'redux';
import { connectRouter } from 'connected-react-router';
import userReducer from './../components/reducers/userReducer';
import storage from 'redux-persist/lib/storage';
import { persistReducer } from 'redux-persist';
import quizReducer from '../components/reducers/quizReducer';

const persistConfig = {
        key: "root",
        storage,
        whitelist: ["user"],
};
const rootReducer = (history) => combineReducers(
        {
                router: connectRouter(history),
                user: userReducer,
                quiz: quizReducer
        }
)
export default rootReducer