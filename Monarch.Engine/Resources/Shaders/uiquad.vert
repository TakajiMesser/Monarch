#version 440

uniform vec2 resolution;
uniform vec2 halfResolution;

layout(location = 0) in vec3 vPosition;
layout(location = 1) in float vBorderThickness;
layout(location = 2) in vec2 vSize;
layout(location = 3) in vec2 vCornerRadius;
layout(location = 4) in vec4 vColor;
layout(location = 5) in vec4 vBorderColor;

layout(location = 0) out vec3 gRight;
layout(location = 1) out vec3 gUp;
layout(location = 2) out vec2 gCornerRadius;
layout(location = 3) out vec2 gBorderThickness;
layout(location = 4) out vec4 gColor;
layout(location = 5) out vec4 gBorderColor;

void main()
{
	float x = (vPosition.x - halfResolution.x) / halfResolution.x;
	float y = (halfResolution.y - vPosition.y) / halfResolution.y;

	gl_Position = vec4(x, y, vPosition.z, 1.0);

	gRight = vec3(vSize.x / halfResolution.x, 0.0, 0.0);
	gUp = vec3(0.0, vSize.y / halfResolution.y, 0.0);
	gCornerRadius = vCornerRadius / vSize;
	gBorderThickness = vec2(vBorderThickness / vSize.x, vBorderThickness / vSize.y);
	gColor = vColor;
	gBorderColor = vBorderColor;
}