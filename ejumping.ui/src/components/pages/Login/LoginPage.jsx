import React, { useEffect } from "react";
import "../Register/Register.scss";
import PropTypes from "prop-types";
import { Formik } from "formik";
import { useDispatch, useSelector } from "react-redux";
import { userExternalLogin, userLoginRequest } from "../../actions/userActions";
import { push } from "connected-react-router";
import { LoginValidation } from "../../validations/RegisterValidation";
import "./Login.scss";
import config from "../../../config.json";
import GoogleLogin from "react-google-login";
import { message } from "antd";
const LoginPage = (props) => {
  const dispatch = useDispatch();
  const isLoggedIn = useSelector((state) => state.user.isLoggedIn);
  const initialValues = {
    userName: "",
    password: "",
  };
  useEffect(() => {
    if (isLoggedIn) {
      dispatch(push("/"));
    }
  }, [isLoggedIn]);
  const userRegisterErrorMsg = "";
  const handleSubmit = (values) => {
    const model = {
      userName: values.userName,
      password: values.password,
    };
    dispatch(userLoginRequest(model));
  };
  const handleExternalLogin = (provider) => {
    // model.provider = provider;
    // model.returnUrl = "/";
    dispatch(userExternalLogin());
    // window.location.href =
    //   "/api/auth/challengeExternalLogin?provider=" + provider + "&returnUrl=/";
  };
  const googleResponseHandler = (response) => {
    dispatch(userExternalLogin(response));
  };
  return (
    <div className="container container__register">
      <h2 className="title">Welcome to Cali Speak</h2>

      <div className="external_login_container">
        <div>Log in with</div>
        <ul className="login_provider">
          <li>
            <GoogleLogin
              className="google"
              clientId={config.GOOGLE_CLIENT_ID}
              buttonText="Google"
              onSuccess={googleResponseHandler}
              onFailure={googleResponseHandler}
            />
          </li>
          <li
            className="facebook"
            onClick={() => handleExternalLogin("Facebook")}
          >
            <div className="logo">
              <img src="https://img.icons8.com/fluent/26/000000/facebook-new.png" />{" "}
            </div>
            <div className="text">Facebook</div>
          </li>
          <li className="apple">
            <div className="logo">
              <img src="https://img.icons8.com/metro/26/000000/mac-os.png" />
            </div>
            <div className="text">Apple</div>
          </li>
        </ul>
        <div className="or-space">----------or-----------</div>
        <div>Log in with your email and password</div>
      </div>
      <div className="card register-card">
        <Formik
          initialValues={initialValues}
          validationSchema={LoginValidation}
          onSubmit={handleSubmit}
        >
          {({
            values,
            errors,
            touched,
            handleChange,
            handleBlur,
            handleSubmit,
            isSubmitting,
          }) => (
            <form onSubmit={handleSubmit} className="register-form-size">
              <div className="form-group">
                <div className="value-text">
                  <label> UserName</label>
                  <input
                    type="text"
                    name="userName"
                    onChange={handleChange}
                    onBlur={handleBlur}
                    value={values.userName}
                    className="ej-input"
                    placeholder="Username"
                  />
                </div>
                <div className="msg-sec">
                  {errors.userName && touched.userName ? (
                    <span className="error-msg">{errors.userName}</span>
                  ) : touched.userName ? (
                    <span className="success-msg">Confirm!</span>
                  ) : (
                    ""
                  )}
                </div>
              </div>

              <div className="form-group">
                <div className="value-text">
                  <label> Password</label>
                  <input
                    type="password"
                    name="password"
                    onChange={handleChange}
                    onBlur={handleBlur}
                    value={values.password}
                    className="ej-input"
                    placeholder="Enter Password"
                  />
                </div>
                <div className="msg-sec">
                  {errors.password && touched.password ? (
                    <span className="error-msg">{errors.password}</span>
                  ) : touched.password ? (
                    <span className="success-msg">Confirm!</span>
                  ) : (
                    ""
                  )}
                </div>
              </div>
              {userRegisterErrorMsg && (
                <div className="server-error-msg text-danger">
                  {userRegisterErrorMsg}
                </div>
              )}

              <div className="bottom-btn">
                <button type="submit" className="ej-button">
                  Login
                </button>
              </div>
            </form>
          )}
        </Formik>
      </div>
    </div>
  );
};

LoginPage.propTypes = {};

export default LoginPage;
