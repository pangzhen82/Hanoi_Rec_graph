#include <stdio.h>
#include <stdlib.h>

int** initial_Matrix (int** matrix, int height)
{
        int i, j;
        matrix = (int**)malloc(sizeof(int*) * 3);
        for(i = 0; i < 3; i++)
        {
                *(matrix + i) = (int*)malloc(sizeof(int) * height);
                for(j = 0; j < height; j++)
                {
                        if(i == 0)
                        {
                                matrix[i][j] = height - j;
                        }
                        else
                        matrix[i][j] = -1;
                }
        }
        return matrix;
}

int moveDisk(int** matrix, int from, int to, int height)
{
        int i, moved_disk;
        for(i = height - 1; i >= 0; i--)
        {
                if(matrix[from - 1][i] != -1)
                {

                        moved_disk = matrix[from - 1][i];
                        matrix[from - 1][i] = -1;
                        break;
                }
        }
        for(i = 0; i < height; i++)
        {
                if(matrix[to - 1][i] == -1)
                {
                        matrix[to - 1][i] = moved_disk;
                        break;
                }
        }
        return moved_disk;
}

void print_Pole(int **matrix, int height)
{
        int i, j;
        printf("\n");
        for(i = 0; i < 3; i++)
        {
                printf("Pole %c: ", 65 + i);
                for(j = 0; j < height; j++)
                {
                        if(matrix[i][j] != -1)
                        {
                                printf("%d ", matrix[i][j]);
                        }
                        else
                                break;
                }
                printf("\n");
        }
}
void print_space(int n)
{
        while(n > 0)
        {
                printf(" ");
                n--;
        }
}

void print_Pole_pic(int** matrix, int height)
{
        int i, j, k;
        printf("\n");
        for(i = 0; i < 3; i++)    // print top of pole
        {
                print_space(height);
                printf("|");
                print_space(height);
                printf("  ");
        }
        printf("\n");

        for(j = height - 1; j >= 0; j--)  // print picture of each pole
        {
                for(i = 0; i < 3; i++)
                {
                        if(matrix[i][j] == -1)
                        {
                                print_space(height);
                                printf("|");
                                print_space(height);
                                printf("  ");
						}
                        else {
                                print_space(height - matrix[i][j] + 1);
                                for(k = 0; k < matrix[i][j] * 2 - 1; k++)
                                        printf("*");
                                print_space(height - matrix[i][j] + 1);
                                printf("  ");
                        }
                }
                printf("\n");
        }

        for(i = 0; i < 3; i++)   //print dotted line
        {
                for(j = 0; j < height * 2 + 1; j++)
                        printf("-");
                printf("  ");
        }
        printf("\n");

        for(i = 0; i < 3; i++)   //print pole name
        {
                print_space(height);
                printf("%c", 65 + i);
                print_space(height);
                printf("  ");
        }
        printf("\n\n");
}

void Hanoi(int n, int a, int b, int c, int height, int** matrix)
{
	int moved_disk;
    if(n == 0)
    {
		return;
    }
    Hanoi(n - 1, a, c, b, height, matrix);
    moved_disk = moveDisk(matrix, a, b, height);
    print_Pole_pic(matrix, height);
    printf("Move disk %d from %c to %c\n", moved_disk, a + 65 - 1, b + 65 - 1);
    Hanoi(n - 1, c, b, a, height, matrix);
}

int main(int argc, char** argv)
{
        int height;
        int **matrix;
        //printf("Enter height of Hanoi:\n");
        //scanf("%d", &height);
	if(argc != 2)
	{
		printf("Error! Input should be: $%s [height]\n", argv[0]);
		return 1;
	}
	height = atoi(argv[1]);
        matrix = initial_Matrix(matrix, height);
        print_Pole_pic(matrix, height);
        Hanoi(height, 1, 3, 2, height, matrix);

        return 0;
}

