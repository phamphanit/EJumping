import { combineReducers } from 'redux';
import { connectRouter } from 'connected-react-router';
import userReducer from './../components/reducers/userReducer';
import storage from 'redux-persist/lib/storage';
import { persistReducer } from 'redux-persist';

const persistConfig = {
        key: "root",
        storage,
        whitelist: ["user"],
};
const rootReducer = (history) => combineReducers(
        {
                router: connectRouter(history),
                user: userReducer
        }
)
export default rootReducer