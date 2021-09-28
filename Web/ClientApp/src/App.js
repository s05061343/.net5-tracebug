import React from 'react'
import { BrowserRouter, Switch } from 'react-router-dom'
import { Redirect, Route } from 'react-router-dom'
import AuthorizedRoute from './store/AuthorizedRoute.js'
import ReactNotification from 'react-notifications-component'
/*import AuthorizedRouteCookie from './store/AuthorizedRouteCookie.js'*/
/*import { HashRouter } from "react-router-dom";*/

// Layouts
import Layout from './components/Layout.jsx';
import Home from './components/Home/Home.jsx';
import Login from './components/Login/Login.jsx';
import MyTask from './components/Login/MyTask.jsx';
import NotFound from './components/Error/NotFound.jsx';
import Unauthorized from './components/Error/Unauthorized.jsx';

import '../src/css/custom.css'
import 'react-notifications-component/dist/theme.css'

export default () => (
    <div>
        <ReactNotification />
        <BrowserRouter>
            <Layout>
                <Switch>
                    <AuthorizedRoute exact path="/home" component={Home} />
                    <AuthorizedRoute path="/login" component={Login} />
                    <AuthorizedRoute path="/" component={MyTask} />
                    <AuthorizedRoute path="/unauthorized" component={Unauthorized} />
                    <Route path="/notfound" component={NotFound} />
                    <Redirect to="/" />
                </Switch>
            </Layout>
        </BrowserRouter>
    </div>
);