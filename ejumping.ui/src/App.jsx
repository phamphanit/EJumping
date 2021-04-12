import { BrowserRouter, Route, Switch } from "react-router-dom";
import HomePage from "./screens/Homepage/index";
import Header from "./partials/Header/index";
import Footer from "./partials/Footer/index";
import RegisterPage from "./components/pages/Register/Register";
import RegisterPageContainer from "./components/pages/Register/RegisterPageContainer";
function App() {
  return (
    <BrowserRouter>
      <Header></Header>
      <div className="container">
        <div className="main-wrapper">
          <main className="container-form">
            <Switch>
              <Route exact path="/" component={HomePage} />
              <Route exact path="/post" component={HomePage} />
              <Route exact path="/register" component={RegisterPageContainer} />
            </Switch>
          </main>
        </div>
      </div>
      <Footer></Footer>
    </BrowserRouter>
  );
}

export default App;
