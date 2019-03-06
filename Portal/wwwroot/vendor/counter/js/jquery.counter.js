// ==========
// Jquery Counter 1.0.0
// ==========
(function (b) {
	b.fn.counter = function (a) {
		function d(b, e, c) {
			var f = parseInt(b.html(), 10) + e;
			f >= c ? (b.html(Math.round(c)), a.callback()) : (b.html(Math.round(f)), setTimeout(function () {
					d(b, e, c)
				}, a.step))
		}

		a = b.extend({
			start: 0, end: 10, time: 10, step: 1E3, callback: function () {
			}
		}, a);
		var g = b(this);
		b(this).html(Math.round(a.start));
		var h = (a.end - a.start) / (1E3 / a.step * a.time);
		setTimeout(function () {
			d(g, h, a.end)
		}, a.step)
	}
})(jQuery);
