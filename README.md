# Configuring ASP.Net Core Applications
This project demonstrates how to configure ASP.Net core applications, and create different middlewares to use them within the application pipeline.

## Features
* Create custom middleware.
	* Content-generating middleware
	* Short-circuiting middleware
	* Request-editing middleware
	* Response-editing middleware
* Configure different sevices in ConfigureServices method in Startup class.
* Configure the pipeline using Configure method in Startup class.
* Create custom WebHostBuilder in BuildWebHost method in Program class.
* Create custom Logging for actions.
* Allow for complex configuration depending on the Hosting Environment.
	* Using if conditions with environment properties in Startup class.
	* Using environment-dependent Json configuration files.
	* Using environment-dependent ConfigureServices and Configure methods in Startup class.
	* Using specific environment-dependent Startup classes.