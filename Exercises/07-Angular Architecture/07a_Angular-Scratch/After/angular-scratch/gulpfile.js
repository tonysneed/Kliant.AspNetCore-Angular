var gulp = require('gulp');

gulp.task('copy', function () {
    return gulp.src(['./src/**/*.{js,html,css,ico}'])
        .pipe(gulp.dest('./dist'));
});
