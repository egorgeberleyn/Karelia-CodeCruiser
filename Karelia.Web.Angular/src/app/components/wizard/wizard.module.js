import angular from 'angular'

import wizardNavigationButtons from './navigation/buttons/wizardNavigationButtons'
import wizardNavigationMenu from './navigation/menu/wizardNavigationMenu'
import wizardPage from './page/wizardPage'

import wizardInput from './controls/input/wizardInput'
import wizardInputLabel from './controls/label/wizardInputLabel'
import wizardCheckbox from './controls/checkbox/wizardCheckbox'
import wizardAutocomplete from './controls/autocompelete/wizardAutocomplete'
import wizardDatePicker from './controls/datepicker/wizardDatePicker'
import wizardDateTimePicker from './controls/datetimepicker/wizardDateTimePicker'
import wizardTimePicker from './controls/timepicker/wizardTimePicker'
import wizardCombobox from './controls/combobox/wizardCombobox'
import wizardNumeric from './controls/numeric/wizardNumeric'
import wizardDropDownList from './controls/dropdownlist/wizardDropDownList'
import wizardMultiline from './controls/multiline/wizardMultiline'

import wizardFileupload from './controls/fileupload/wizardFileupload'

import customValidation from './controls/validation/customValidation'

import wizard from './wizard/wizard'

const app = angular.module('app.wizard', []);


app.component('wizardNavigationButtons', wizardNavigationButtons);
app.component('wizardNavigationMenu', wizardNavigationMenu);
app.component('wizardPage', wizardPage);
app.component('wizard', wizard);

app.component('wizardInput', wizardInput);
app.component('wizardInputLabel', wizardInputLabel);
app.component('wizardCheckbox', wizardCheckbox);
app.component('wizardAutocomplete', wizardAutocomplete);
app.component('wizardDatepicker', wizardDatePicker);
app.component('wizardDatetimepicker', wizardDateTimePicker);
app.component('wizardTimepicker', wizardTimePicker);
app.component('wizardDropDownList', wizardDropDownList);
app.component('wizardMultiline', wizardMultiline);

app.component('wizardFileupload', wizardFileupload);

app.component('wizardCombobox', wizardCombobox);
app.component('wizardNumeric', wizardNumeric);
app.directive('customValidation', customValidation);




