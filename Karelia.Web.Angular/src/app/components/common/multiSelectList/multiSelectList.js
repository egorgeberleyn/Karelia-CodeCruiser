import template from "./multiSelectList.html";
import './multiSelectList.scss';

class MiltiSelectListController {
}

export default {
  template,
  bindings: {
    items: "=",
    valueField: "=",
    displayField: "="
  },
  controller: MiltiSelectListController
}