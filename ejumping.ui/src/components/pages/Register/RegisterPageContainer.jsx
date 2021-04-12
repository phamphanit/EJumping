import { connect } from "react-redux";
import RegisterPage from "./Register";

const mapDispatchToProps = (dispatch) => ({
  dispatchUserRegisterRequested: (model) =>
    dispatch(userRegisterRequested(model)),
});

export default RegisterPageContainer = connect(
  null,
  mapDispatchToProps
)(RegisterPage);
