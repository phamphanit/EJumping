import userActionTypes from "../constant/userActionTypes";
import axios from 'axios';
import { Cookies } from 'react-cookie';
const initialState = {
        isRegistered: false,
        isLoggedIn: false,
        userRegisterErrorMsg: null,
        userLoginErrorMsg: null,
        access_token: null,
        myInfo: null
}
const userReducer = (state = initialState, action) => {
        switch (action.type) {
                case userActionTypes.USER_REGISTER_SUCCESS:
                        return {
                                ...state,
                                isRegistered: true
                        };
                case userActionTypes.USER_REGISTER_FAILURE:

                        return {
                                ...state,
                                isRegistered: false,
                                userRegisterErrorMsg: action.payload
                        };
                case userActionTypes.USER_LOGIN_SUCCESS:
                        axios.defaults.headers.common['Authorization'] = 'Bearer ' + action.payload.access_token;
                        var cookies = new Cookies();
                        cookies.set("act", action.payload.access_token)
                        return {
                                ...state,
                                isLoggedIn: true,
                                userRegisterErrorMsg: "",
                                access_token: action.payload
                        }
                case userActionTypes.USER_LOGIN_FAILURE:
                        return {
                                ...state,
                                userLoginErrorMsg: action.payload
                        }
                case userActionTypes.USER_LOGOUT_SUCCESS:
                        return {
                                ...state,
                                isLoggedIn: false,
                                access_token: null,
                                myInfo: null
                        }
                case userActionTypes.FETCH_MYINFO_SUCCEEDED:
                        return {
                                ...state,
                                myInfo: action.payload
                        }
                default:
                        return state;
        }
}
export default userReducer;