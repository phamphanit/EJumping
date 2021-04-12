import { connect } from "react-redux";
import RegisterPage from "./Register";
import { userRegisterRequested } from "./../../actions/userActions";
const mapDispatchToProps = (dispatch) => ({
  dispatchUserRegisterRequested: (model) =>
    dispatch(userRegisterRequested(model)),
});

const RegisterPageContainer = connect(null, mapDispatchToProps)(RegisterPage);
export default RegisterPageContainer;
