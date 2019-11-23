// Librerias React
import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";

// Componentes
import { FetchData } from "./components/FetchData";
import  MiTurno  from "./components/MiTurno";
import Turno from "./components/Turno";

// Autorizaciones
import AuthorizeRoute from "./components/api-authorization/AuthorizeRoute";
import ApiAuthorizationRoutes from "./components/api-authorization/ApiAuthorizationRoutes";
import { ApplicationPaths } from "./components/api-authorization/ApiAuthorizationConstants";

import "./custom.css";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path="/" component={Turno} />
        <Route exact path="/miturno" component={MiTurno} />
        {/* <AuthorizeRoute path='/' component={Home} /> */}
        {/* <Route exact path='/' component={Home} /> */}
        <AuthorizeRoute exact path="/fetch-data" component={FetchData} />
        {/* <AuthorizeRoute path='/counter' component={Counter} /> */}
        {/* <Route exact path='fetch-data' component={FetchData}/> */}

        <Route
          path={ApplicationPaths.ApiAuthorizationPrefix}
          component={ApiAuthorizationRoutes}
        />
      </Layout>
    );
  }
}
