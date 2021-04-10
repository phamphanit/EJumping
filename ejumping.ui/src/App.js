import './App.css';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import HomePage from './screens/Homepage/index';
import Contact from './screens/Contact/index';
import PostPage from './screens/Postpage/index';
import Blog from './screens/Blog/index';
import Header from './partials/Header/index';
function App() {
  return (
    <BrowserRouter>
      <Header></Header>
      <Switch>
        <Route exact path='/' component={HomePage} />
        <Route exact path='/contact' component={Contact} />
        <Route exact path='/post' component={PostPage} />
        <Route exact path='/blog' component={Blog} />
      </Switch>
    </BrowserRouter>
  );
}

export default App;
