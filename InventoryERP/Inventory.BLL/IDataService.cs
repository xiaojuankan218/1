using System.Data;

namespace Inventory.BLL
{
    public interface IDataService<T>
    {
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <returns></returns>
        int Insert(T t);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int Update(T t);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(string no);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataTable Query(string strWhere);

        /// <summary>
        /// 根据编号查询单个对象
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        T GetSingleByno(string no);

    }
}