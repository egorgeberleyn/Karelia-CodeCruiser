export default class StringFormat {
  format(format, args) {
    var result = format;
    for (var i = 0; i < args.length; i++) {
      var r = new RegExp("\\{" + i + "\\}", "g");
      result = result.replace(r, args[i].toString());
    }
    return result;
  }
}
