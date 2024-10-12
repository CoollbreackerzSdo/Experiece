using ConsoleDump;

var initialValue = 9109211;
(TelemetryBuffer.FromBuffer(TelemetryBuffer.ToBuffer(initialValue)) == initialValue).Dump();