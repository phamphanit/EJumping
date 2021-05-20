import { WebStorageStateStore } from "oidc-client";

const oidcConfig = {
  authority: "https://localhost:44386",
  client_id: "EJumping.React",
  redirect_uri: `http://localhost:3000/oidc-login-redirect`,
  scope: "openid profile EJumping.WebAPI",
  response_type: "code",
  post_logout_redirect_uri: `http://localhost:3000/oidc-logout-redirect`,
  userStore: new WebStorageStateStore({ store: window.localStorage }),
};
export default oidcConfig;
