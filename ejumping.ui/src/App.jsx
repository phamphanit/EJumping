import { BrowserRouter, Route, Switch } from "react-router-dom";
import HomePage from "./screens/Homepage/index";
import Header from "./partials/Header/index";
import Footer from "./partials/Footer/index";
import Register from "./components/pages/Register/Register";
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
              <Route exact path="/register" component={Register} />
            </Switch>
          </main>
        </div>
      </div>
      <Footer></Footer>
    </BrowserRouter>
  );
}

export default App;
