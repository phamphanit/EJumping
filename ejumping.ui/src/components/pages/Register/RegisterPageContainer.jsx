import { connect } from "react-redux";
import RegisterPage from "./Register";
import { push } from "connected-react-router";
import { userRegisterRequested } from "./../../actions/userActions";
const mapDispatchToProps = (dispatch) => ({
  dispatchUserRegisterRequested: (model) =>
    dispatch(userRegisterRequested(model)),
  dispatchUrl: (url) => dispatch(push(url)),
});
const mapStateToProps = (state) => ({
  userRegisterErrorMsg: state.user.userRegisterErrorMsg,
  isLoggedIn: state.user.isLoggedIn,
});
const RegisterPageContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(RegisterPage);
export default RegisterPageContainer;
