import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Views } from './components/Views';
import { ViewResult } from './components/ViewResult';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/views' component={Views} />
        <Route path='/view/' component={ViewResult} />
      </Layout>
    );
  }
}
