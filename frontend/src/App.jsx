import React from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom'

import Listagem from './components/Listagem'
import Header from './components/Header'
import Form from './components/Form'

import 'antd/dist/antd.css';
import 'bootstrap/dist/css/bootstrap.min.css'

export default function App() {
  return (
    <div className="App">
    <Header />
    <BrowserRouter>
      <Switch>
        <Route path='/' component={Form} exact />
        <Route path='/Listagem' component={Listagem} />
      </Switch>
    </BrowserRouter> 
    </div>
  );
}
