import valueFormatter from './valueFormatter';

export default () => {
    return function (input, dataType, format) {
        return valueFormatter.format(input, format, dataType);
    };
}
