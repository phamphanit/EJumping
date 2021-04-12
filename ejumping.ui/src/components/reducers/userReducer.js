import { act } from "react-dom/test-utils";
import userActionTypes from "../constant/userActionTypes";

const initialState = {
        isRegistered: false,
        userRegisterErrorMsg: null
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
                default:
                        return state;
        }
}
export default userReducer;