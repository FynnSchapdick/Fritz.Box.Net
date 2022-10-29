// Global using directives

global using System.Net;
global using FritzBoxPrometheusExporter.Collectors;
global using HealthChecks.UI.Client;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Microsoft.Extensions.Options;
global using Prometheus.Client;
global using Prometheus.Client.AspNetCore;
global using Prometheus.Client.DependencyInjection;
global using ICollector = FritzBoxPrometheusExporter.Collectors.Abstractions.ICollector;
global using ICounter = Prometheus.Client.ICounter;
global using IMetricFactory = Prometheus.Client.IMetricFactory;