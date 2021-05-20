import { UserManager, WebStorageStateStore } from "oidc-client";
import { useEffect } from "react";
import { useHistory } from "react-router";
import { useDispatch } from "react-redux";
import { userLogoutSuccess } from "../../actions/userActions";

const OidcLogoutRedirect = () => {
  const config = {
    userStore: new WebStorageStateStore({ store: window.localStorage }),
    response_mode: "query",
  };
  const dispatch = useDispatch();
  const mgr = new UserManager(config);
  const history = useHistory();
  useEffect(() => {
    async function signoutAsync() {
      await mgr.signoutRedirectCallback();

      // redirect user to home page
      dispatch(userLogoutSuccess());
      history.push("/");
    }
    signoutAsync();
  }, []);

  return <div>Loadingasdasdgg</div>;
};

export default OidcLogoutRedirect;
