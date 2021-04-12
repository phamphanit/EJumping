import React from "react";
import PropTypes from "prop-types";
import { Formik } from "formik";
import * as Validation from "../../validations/RegisterValidation";
import * as Yup from "yup";
import "./Register.scss";
export default class RegisterPage extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      tosAgreed: false,
      errors: {},
      validationError: "",
      validationErrorParam: {},
      isLoading: false,
    };
    this.handleToggleCheckTos = this.handleToggleCheckTos.bind(this);
    this.getValidationSchema = this.getValidationSchema.bind(this);
    this.validate = this.validate.bind(this);
  }
  initialValues = {
    password: "",
    email: "",
    paswordConfirm: "",
    userName: "",
  };
  handleToggleCheckTos() {
    this.setState({ tosAgreed: !this.state.tosAgreed });
  }
  getValidationSchema(values) {
    return Validation.RegisterValidation(values);
  }
  validate(values) {
    const validationSchema = this.getValidationSchema(values);
    try {
      validationSchema.validateSync(values, { abortEarly: false });
    } catch (error) {
      return this.getErrorsFromValidationError(error);
    }
    return {};
  }
  getErrorsFromValidationError(validationError) {
    const FIRST_ERROR = 0;
    return validationError.inner.reduce((errors, error) => {
      return {
        ...errors,
        [error.path]: error.errors[FIRST_ERROR],
      };
    }, {});
  }
  render() {
    return (
      <div className="container container__register">
        <div className="card register-card">
          <h4 className="title">Sign Up</h4>
          <Formik initialValues={this.initialValues} validate={this.validate}>
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
                    <label> User Name</label>
                    <input
                      type="email"
                      name="userName"
                      onChange={handleChange}
                      onBlur={handleBlur}
                      value={values.userName}
                      className="form-control"
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
                    <label> Email</label>
                    <input
                      type="email"
                      name="email"
                      onChange={handleChange}
                      onBlur={handleBlur}
                      value={values.email}
                      className="form-control"
                    />
                  </div>
                  <div className="msg-sec">
                    {errors.email && touched.email ? (
                      <span className="error-msg">{errors.email}</span>
                    ) : touched.email ? (
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
                <div className="form-group">
                  <div className="value-text">
                    <label> Confirm Password</label>
                    <input
                      type="password"
                      name="passwordConfirm"
                      onChange={handleChange}
                      onBlur={handleBlur}
                      value={values.passwordConfirm}
                      className="form-control"
                    />
                  </div>
                  <div className="msg-sec">
                    {errors.passwordConfirm && touched.passwordConfirm ? (
                      <span className="error-msg">
                        {errors.passwordConfirm}
                      </span>
                    ) : touched.passwordConfirm ? (
                      <span className="success-msg">Confirm!</span>
                    ) : (
                      ""
                    )}
                  </div>
                </div>
                <div className="bottom-btn">
                  <button
                    type="submit"
                    class="btn btn-info"
                    disabled={isSubmitting}
                  >
                    Submit
                  </button>
                </div>
              </form>
            )}
          </Formik>
        </div>
      </div>
    );
  }
}
