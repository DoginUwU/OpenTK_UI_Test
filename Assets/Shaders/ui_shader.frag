#version 330 core

in vec4 BackgroundColor;
in vec2 texCoord;

uniform sampler2D texture0;
uniform int hasTexture;

out vec4 FragColor;

void main()
{
	if(hasTexture == 1) {
		FragColor = texture(texture0, texCoord);
	} else {
		FragColor = BackgroundColor;
	}
}