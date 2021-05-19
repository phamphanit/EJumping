import { Route, Switch } from "react-router-dom";
import HomePage from "./components/pages/Homepage/index";
import Header from "./partials/Header/index";
import Footer from "./partials/Footer/index";
import RegisterPageContainer from "./components/pages/Register/RegisterPageContainer";
import LoginPage from "./components/pages/Login/LoginPage";
import FeaturePage from "./components/pages/FeaturePage/Feature";
import { PageMenu } from "./partials/Menu/PageMenu";
import QuizPage from "./components/pages/QuizPage";
import OidcLoginRedirect from "./components/pages/Login/OidcLoginRedirect";
function App() {
  return (
    <div>
      <Header></Header>
      <PageMenu></PageMenu>

      <main className="main-wrapper">
        <Switch>
          <Route exact path="/" component={HomePage} />
          <Route
            exact
            path="/oidc-login-redirect"
            component={OidcLoginRedirect}
          />
          <Route exact path="/feature" component={FeaturePage} />
          <Route exact path="/register" component={RegisterPageContainer} />
          <Route exact path="/login" component={LoginPage}></Route>
          <Route exact path="/quiz" component={QuizPage}></Route>
        </Switch>
      </main>
      <Footer></Footer>
    </div>
  );
}

export default App;
