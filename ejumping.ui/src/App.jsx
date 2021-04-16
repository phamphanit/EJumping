import { Route, Switch } from "react-router-dom";
import HomePage from "./components/pages/Homepage/index";
import Header from "./partials/Header/index";
import Footer from "./partials/Footer/index";
import RegisterPageContainer from "./components/pages/Register/RegisterPageContainer";
import LoginPage from "./components/pages/Login/LoginPage";
import FeaturePage from "./components/pages/FeaturePage/Feature";
function App() {
  return (
    <div>
      <Header></Header>
      <div className="container">
        <div className="main-wrapper">
          <main className="container-form">
            <Switch>
              <Route exact path="/" component={HomePage} />
              <Route exact path="/feature" component={FeaturePage} />
              <Route exact path="/register" component={RegisterPageContainer} />
              <Route exact path="/login" component={LoginPage}></Route>
            </Switch>
          </main>
        </div>
      </div>
      <Footer></Footer>
    </div>
  );
}

export default App;
