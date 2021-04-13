import * as Yup from 'yup';
export const RegisterValidation = (values) =>
        Yup.object().shape({
                userName: Yup.string()
                        .min(2, "validation.register.idhastobemorethancharacters")
                        .max(12, "validation.register.idhastobemorethancharacters")
                        .required("validation.register.youhavetohavenickname"),
                // password: Yup.string().matches(/^(?=.*[A-Z])(?=.*\d)(?=.*[^\w])(?!.*[=&?<>]).{6,12}$/, "validation.register.pleaseusealphanumeric").required(
                //         "validation.register.youhavetohavepassword"
                // ),
                passwordConfirm: Yup.string()
                        .oneOf([values.password], 'validation.register.passwordsarenotthesame')
                        .required(
                                "validation.register.youhavetohavepasswordconfirm"
                        ),
                email: Yup.string().email("validation.register.emailhastomatchemailformat").required(
                        "validation.register.emailisrequired"
                ),
        })
export const LoginValidation = Yup.object().shape({
        userName: Yup.string()
                .required(
                        "validation.login.usernameisrequired"
                ),
        password: Yup.string()
                .required(
                        "validation.login.passwordisrequired"
                )
});
