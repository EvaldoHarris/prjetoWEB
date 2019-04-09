import * as React from 'react';
import { Route, Redirect } from 'react-router-dom';

import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Login } from './components/Login';

import { Autorizacao } from './components/Autorizacao';

//Usuario
import { FetchUsuario } from './components/FetchUsuario';
import { AddUsuario } from './components/AddUsuario';
//Curso
import { FetchCurso } from './components/FetchCurso';
import { AddCurso } from './components/AddCurso';
//Disciplina
import { FetchDisciplina } from './components/FetchDisciplina';
import { AddDisciplina } from './components/AddDisciplina';





export const PrivateRoute = ({ component: Component, ...rest }) => (
    <Route {...rest} render={props => (
        localStorage.getItem('user') == "admin" || localStorage.getItem('user') == "professor" || localStorage.getItem('user') == "nde"
            ?
            <Component {...props} />
            : <Redirect to={{ pathname: '/login', state: { from: props.location } }} />
    )} />
)

export const CoordenadorRoute = ({ component: Component, ...rest }) => (
    <Route {...rest} render={props => (
        localStorage.getItem('user') == "admin" || localStorage.getItem('user') == "nde"
            ?
            <Component {...props} />
            : localStorage.getItem('user') == "professor" ?
                <Redirect to={{ pathname: '/autorizacao', state: { from: props.location } }} />
                : <Redirect to={{ pathname: '/login', state: { from: props.location } }} />

    )} />
)

export const AdminRoute = ({ component: Component, ...rest }) => (
    <Route {...rest} render={props => (
        localStorage.getItem('user') == "admin"
            ?
            <Component {...props} />
            : localStorage.getItem('user') == "professor" || localStorage.getItem('user') == "nde" ? 
                <Redirect to={{ pathname: '/autorizacao', state: { from: props.location } }} /> 
                : <Redirect to={{ pathname: '/login', state: { from: props.location } }} />
            
    )} />
)

export const routes = <Layout>

    <Route path='/login' component={Login} />

    <PrivateRoute exact path='/' component={Home} />
    <PrivateRoute path='/home' component={Home} />
    <PrivateRoute path='/autorizacao' component={Autorizacao} />

    <AdminRoute path='/fetchusuario' component={FetchUsuario} />
    <AdminRoute path='/usuario/adicionar' component={AddUsuario} />
    <AdminRoute path='/usuario/editar/:id' component={AddUsuario} />

    <AdminRoute path='/fetchcurso' component={FetchCurso} />
    <AdminRoute path='/curso/adicionar' component={AddCurso} />
    <AdminRoute path='/curso/editar/:id' component={AddCurso} />

    <CoordenadorRoute path='/fetchdisciplina' component={FetchDisciplina} />
    <CoordenadorRoute path='/disciplina/adicionar' component={AddDisciplina} />
    <CoordenadorRoute path='/disciplina/editar/:id' component={AddDisciplina} />

</Layout>;


