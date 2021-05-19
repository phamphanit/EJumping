import { Divider } from "antd";
import { UserManager, User, WebStorageStateStore } from "oidc-client";
import { useEffect } from "react";
import { useHistory } from "react-router";

const OidcLoginRedirect = () => {
  const config = {
    userStore: new WebStorageStateStore({ store: window.localStorage }),
    response_mode: "query",
  };
  const mgr = new UserManager(config);
  const history = useHistory();
  console.log("aaaaaa");
  useEffect(() => {
    async function signinAsync() {
      await mgr.signinRedirectCallback();
      // redirect user to home page
      history.push("/");
    }
    signinAsync();
  }, [history]);

  return <div>Loadinggg</div>;
};

export default OidcLoginRedirect;
