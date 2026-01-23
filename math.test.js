// math.test.js
const divide = require('./math');

describe('divide function', () => {
  test('divides two positive numbers correctly', () => {
    expect(divide(10, 2)).toBe(5);
  });

  test('divides two negative numbers correctly', () => {
    expect(divide(-10, -2)).toBe(5);
  });

  test('handles division with zero numerator', () => {
    expect(divide(0, 5)).toBe(0);
  });

  test('throws error when dividing by zero', () => {
    expect(() => divide(10, 0)).toThrow('Division by zero is not allowed');
  });

  test('handles decimal division', () => {
    expect(divide(10, 4)).toBe(2.5);
  });
});
