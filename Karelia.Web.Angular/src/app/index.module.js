import angular from 'angular'

import './vendors'

import './css/index.scss'

import './services/services.module';
import './domain/domain.module'
import './components/wizard/wizard.module'
import './registration/registration.module'

import config from './index.config' 
import run from './index.run' 

import spinner from './components/common/spinner/spinner'
import welcome from './components/welcome/welcome'
import login from './components/login/login'
import screen from './components/screen/screenComponent'
import mainLayout from './components/mainLayout/mainLayoutComponent'
import gridBlock from './components/screen/dataBlocks/grid/gridBlock'
import chartBlock from './components/screen/dataBlocks/chart/chartBlock';
import grid from './components/common/grid/grid'
import toolbar from './components/common/toolbar/toolbar'
import menuActions from './components/actions/menuActions'
import splitContainer from './components/screen/splitContainer/splitContainer'
import confirmationDialog from './components/common/confirmationDialog/confirmationDialog.js'
import tabContainer from './components/screen/tabContainer/tabContainer'
import tabItem from './components/screen/tabContainer/tabItem';
import detailsBlock from './components/screen/dataBlocks/details/detailsBlock'
import quickSearch from './components/common/quickSearch/quickSearch'
import photo from './components/common/photo/photo'
import reportViewer from './components/common/reportViewer/reportViewer'
import cancelableProgress from './components/common/cancelableProgress/cancelableProgress';
import fileLink from './components/common/fileLink/fileLink';
import multiSelectList from './components/common/multiSelectList/multiSelectList';
import multiSelectListForm from './components/userManagement/multiSelectListForm';

import formatterFilter from './services/formatters/formatterFilter'



const dependecies = [
    'ui.router',
    'ngMessages',
    'pascalprecht.translate',
    'kendo.directives',
    'angularCSS',
    'app.domain',
    'app.wizard',
    'app.services',
    'app.registration',
    'pdfjsViewer'
];
const app = angular.module('app', dependecies);
app.config(config);
app.run(run);

app.component('spinner', spinner);
app.component('welcome', welcome);
app.component('login', login);
app.component('screen', screen);
app.component('mainLayout', mainLayout);
app.component('gridBlock', gridBlock);
app.component('chartBlock', chartBlock);
app.component('grid', grid);
app.component('toolbar', toolbar);
app.component('menuActions', menuActions);
app.component('splitContainer', splitContainer);
app.component('confirmationDialog', confirmationDialog);
app.component('tabContainer', tabContainer);
app.component('tabItem', tabItem);
app.component("detailsBlock", detailsBlock);
app.component("quickSearch", quickSearch);
app.component("photo", photo);
app.component("reportViewer", reportViewer);
app.component("cancelableProgress", cancelableProgress);
app.component("fileLink", fileLink);
app.component('multiSelectList', multiSelectList);
app.component('multiSelectListForm', multiSelectListForm);

app.filter("formatterFilter", formatterFilter);




