using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pazzle : MonoBehaviour
{

     // タイルの種類
    public enum TileType
    {
        NONE,   // 何も無い
        GROUBD, // 地面
        CANDY,  // キャンディー
        BLOCK,  // ブロック
        SPONE,  // スポーンブロック

        SCORE, // 点数
    }

    private int rows = 7;             // 行数    // 変更予定
    private int columns  = 7;         // 列数    // 変更予定
    public TextAsset stageFile; // ステージ構造が記述されたテキストファイル

    // タイルの情報を読み込む
    private void LoadTileData()
    {
        // タイルの情報を一行ごとに分割
        var lines = stageFile.text.Split
        (
            new[] { '\r', '\n' },
            System.StringSplitOptions.RemoveEmptyEntries
        );

        // タイルの列数を計算
        var nums = lines[ 0 ].Split( new[] { ',' } );

        // タイルの列数と行数を保持
        rows = lines.Length; // 行数
        columns = nums.Length; // 列数

        // タイル情報を int 型の２次元配列で保持
        tileList = new TileType[ columns, rows ];
        for ( int y = 0; y < rows; y++ )
        {
            var st = lines[ y ];
            nums = st.Split( new[] { ',' } );
            for ( int x = 0; x < columns; x++ )
            {
                tileList[ x, y ] = ( TileType )int.Parse( nums[ x ] );
            }
        }
    }

    public Sprite groundSprite;  // 地面のスプライト
    public Sprite blockSprite;   // ブロックのスプライト
    public TileType[,] tileList; // タイル情報を管理する二次元配列
    public int[,] color;         // キャンディの色を管理する二次元配列

    private Vector3 middleOffset;// 中心位置
    public float tileSize;       // タイルのサイズ

    // ステージを作成
    private void CreateStage()
    {

        tileList = new TileType[ columns, rows ];
        color = new int[ columns, rows ];
        int K_ = 5;  // K種類

        for ( int y = 0; y < rows; y++ )
        {
            for ( int x = 0; x < columns; x++ )
            {
                tileList[ x, y ] = ( TileType ) 1;
                color[ x, y ] = K_;
            }
        }

        // ステージの中心位置を計算
        middleOffset.x = columns * tileSize * 0.5f - tileSize * 0.5f;
        middleOffset.y = rows * tileSize * 0.5f - tileSize * 0.5f;

        // キャンディの配置を乱数生成 

        for ( int y = 0; y < rows; y++ )
        {
            for ( int x = 0; x < columns; x++ )
            {
                if ( tileList[ x, y ] == TileType.NONE ) 
                {
                    color[ x, y ] = K_;
                    continue;
                }
                List<int> v_ = new List<int>();  // 配置可能な種類を入れる配列
                for(int p = 0; p < K_; p++)
                {
                    bool flag = true;
                    if(x >= 2)
                    {
                        if( p == color[x - 1, y] && p == color[x - 2, y])
                        {
                            flag = false;
                        }
                    }
                    if(y >= 2){
                        if( p == color[x, y - 1] && p == color[x, y - 2])
                        {
                            flag = false;
                        }
                    }
                    if(flag)
                    {
                        v_.Add(p);
                    }
                }
                color[x,y] = v_[Random.Range(0, v_.Count)];
            }
        }

        // タイルの貼り付け

        int z = 0;  // 変更予定

        for ( int y = 0; y < rows; y++ )
        {
            for ( int x = 0; x < columns; x++ )
            {
                var val = tileList[ x, y ];
                // 何も無い場所は無視
                if ( val == TileType.NONE ) continue;
                // タイルの名前に行番号と列番号を付与
                var name = "tile" + y + "_" + x;
                // タイルのゲームオブジェクトを作成
                var tile = new GameObject( name ); 
                // タイルにスプライトを描画する機能を追加
                var sr = tile.AddComponent<SpriteRenderer>();
                // タイルのスプライトを設定
                sr.sprite = groundSprite;
                // タイルの位置を設定
                tile.transform.position = GetDisplayPosition( x , y , z );   
            }
        }
    }

    // 指定された行番号と列番号からスプライトの表示位置を計算して返す
    private Vector3 GetDisplayPosition( int x, int y , int z )
    {
        return new Vector3
        (
            x *  tileSize - middleOffset.x,
            y * -tileSize + middleOffset.y,
            z
        );
    }

    // Start is called before the first frame update
    void Start()
    {
        // LoadTileData(); // タイルの情報を読み込む
        CreateStage(); // ステージを作成
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
