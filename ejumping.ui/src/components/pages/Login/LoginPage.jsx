import React, { useEffect } from "react";
import PropTypes from "prop-types";
import { Formik } from "formik";
import { useDispatch, useSelector } from "react-redux";
import { userLoginRequest } from "../../actions/userActions";
import { push } from "connected-react-router";
import { LoginValidation } from "../../validations/RegisterValidation";
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
  return (
    <div className="container container__register">
      <div className="card register-card">
        <h4 className="title">Sign In</h4>
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
                  <label> ID</label>
                  <input
                    type="text"
                    name="userName"
                    onChange={handleChange}
                    onBlur={handleBlur}
                    value={values.userName}
                    className="form-control"
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
                    className="form-control"
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
                <button type="submit" className="btn btn-info">
                  Submit
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
