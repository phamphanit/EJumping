import { combineReducers } from 'redux';
import userReducer from './../components/reducers/userReducer';
const rootReducer = combineReducers(
        {
                user: userReducer
        }
)
export default rootReducer;