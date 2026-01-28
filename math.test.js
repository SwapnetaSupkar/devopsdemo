// math.test.js
const assert = require('assert');
const divide = require('./math');

// basic division
assert.strictEqual(divide(10, 2), 5, '10 / 2 should equal 5');

// negative numbers
assert.strictEqual(divide(-9, 3), -3, '-9 / 3 should equal -3');

// division by zero should throw
let threw = false;
try {
  divide(1, 0);
} catch (err) {
  threw = true;
  assert.strictEqual(err.message, 'Division by zero', 'Error message should indicate division by zero');
}

assert.ok(threw, 'divide should throw when dividing by zero');

console.log('All math.js tests passed.');
