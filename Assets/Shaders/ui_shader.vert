#version 330 core

layout (location = 0) in vec2 position; // Vertex coordinates

out vec2 texCoord;

uniform mat4 view;
uniform mat4 projection;

void main()
{
	gl_Position = vec4(position, 0.0,  1.0) * view * projection; // Coordinates return
}