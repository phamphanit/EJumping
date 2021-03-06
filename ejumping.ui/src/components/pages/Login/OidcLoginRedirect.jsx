import { UserManager, WebStorageStateStore } from "oidc-client";
import { useEffect } from "react";
import { useHistory } from "react-router";

const OidcLoginRedirect = () => {
  const config = {
    userStore: new WebStorageStateStore({ store: window.localStorage }),
    response_mode: "query",
  };
  const mgr = new UserManager(config);
  const history = useHistory();
  useEffect(() => {
    async function signinAsync() {
      await mgr.signinRedirectCallback();
      // redirect user to home page
      history.push("/");
    }
    signinAsync();
  }, []);

  return <div>Loadinggg</div>;
};

export default OidcLoginRedirect;
